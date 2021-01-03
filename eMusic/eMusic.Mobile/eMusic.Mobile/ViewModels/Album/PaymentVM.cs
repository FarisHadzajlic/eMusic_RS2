using Acr.UserDialogs;
using eMusic.Mobile.Helper;
using eMusic.Mobile.Models;
using eMusic.Mobile.Views.Album;
using eMusic.Model;
using eMusic.Model.Request;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.Album
{
    public class PaymentVM : BaseVM
    {
        private readonly APIService buyAlbumService = new APIService("BuyAlbum");
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public PaymentVM()
        {

        }
        public PaymentVM(INavigation nav)
        {
            this.Navigation = nav;
            SubmitCommand = new Command(async () => await BuyAlbum());
        }

        private readonly INavigation Navigation;
        public MAlbum Album { get; set; }

        private string StripeTestApiKey = "pk_test_GV7CFLcgjHOmSZYvz5rmelS900NINc2cGI";

        private CreditCard _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private string _number;
        private string _cvc;

        MUser user = SignedInUser.User;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
        public string Cvc
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }
        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }
        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        public CreditCard CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }
        public ICommand SubmitCommand { get; set; }
        private async Task<string> CreateTokenAsync()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;

                var Tokenoptions = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = user.FirstName + " " + user.LastName,
                        AddressLine1 = "Zeljznicka 14a",
                        AddressLine2 = "11",
                        AddressCity = "Konjic",
                        AddressZip = "88400",
                        AddressState = "Konjic12",
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> MakePaymentAsync(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_coMLyIb6JOSv9IlfMOx5Fj1g0023rONhFx";

                var options = new ChargeCreateOptions();

                options.Amount = Convert.ToInt64(Album.Price) * 100;
                options.Currency = "usd";
                options.Description = Album.Name;
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = user.Email.ToString();
                var service = new ChargeService();
                Charge charge = service.Create(options);
                UserDialogs.Instance.Alert("Purchase was successful!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(Album.Name + " (CreateCharge)" + ex.Message);
                throw ex;
            }
        }
        public async Task BuyAlbum()
        {
            var albums = await buyAlbumService.Get<List<MBuyAlbum>>(null);
            bool have = false;
            foreach(var x in albums)
                if (x.UserID == user.UserID && Album.AlbumID == x.AlbumID)
                    have = true;

            if (have == true)
            {
                await App.Current.MainPage.DisplayAlert("Information", "You already bought this album!", "OK");
            }
            else
            {
                if (ExpMonth == null || ExpMonth == "" || ExpYear == null || ExpYear == "" || Number == null || Number == "" || Cvc == null || Cvc == "")
                {
                    UserDialogs.Instance.Alert("You have to fill all fields!", "Payment failed", "OK");
                    return;
                }
                if (ExpMonth != null || ExpMonth != "" || ExpYear != null || ExpYear != "" || Number != null || Number != "" || Cvc != null || Cvc != "")
                {
                    if (!IsDigitsOnly(ExpMonth) || !IsDigitsOnly(ExpMonth) || !IsDigitsOnly(Number) || !IsDigitsOnly(Cvc))
                    {
                        UserDialogs.Instance.Alert("You can't use letters!", "Payment failed", "OK");
                        return;
                    }
                }
                CreditCardModel = new CreditCard();
                CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth); 
                CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
                CreditCardModel.Number = Number;
                CreditCardModel.Cvc = Cvc;
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;               
                try
                {
                    UserDialogs.Instance.ShowLoading("Payment processing ...");
                    await Task.Run(async () =>
                    {
                        var Token = CreateTokenAsync();
                        Console.Write(Album.Name + "Token :" + Token);
                        if (Token.ToString() != null)
                        {
                            IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Bad Card Credentials", null, "OK");
                        }
                    });
                }
                catch(Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message, null, "OK");
                    Console.Write(Album.Name + ex.Message);
                }
                finally
                {
                    if (IsTransectionSuccess)
                    {
                        var request = new BuyAlbumRequest()
                        {
                            DateOfBuying = DateTime.Now,
                            AlbumID = Album.AlbumID,
                            UserID = user.UserID,
                            Price = Album.Price,
                            Username = user.Username,
                            AlbumName = Album.Name
                        };
                        await buyAlbumService.Insert<MBuyAlbum>(request);
                        await Navigation.PushAsync(new AlbumPage());
                        Console.Write(Album.Name + "Payment Successful ");
                        UserDialogs.Instance.HideLoading();
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        //UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                        Console.Write(Album.Name + "Payment Failure ");
                    }
                }
            }
        }
    }
}
