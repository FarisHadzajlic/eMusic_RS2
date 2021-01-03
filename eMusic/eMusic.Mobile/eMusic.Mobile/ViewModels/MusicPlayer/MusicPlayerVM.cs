using eMusic.Mobile.Helper;
using eMusic.Model;
using eMusic.Model.Request;
using MediaManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eMusic.Mobile.ViewModels.MusicPlayer
{
    public class MusicPlayerVM : BaseVM
    {
        private readonly APIService trackService = new APIService("Track");
        private readonly APIService reviewService = new APIService("Review");
        ObservableCollection<MTrack> trackList;
        public ObservableCollection<MTrack> TrackList
        {
            get { return trackList; }
            set
            {
                trackList = value;
                OnPropertyChanged();
            }
        }
        private MTrackReview trackReview;
        public MTrackReview TrackReview
        {
            get { return trackReview; }
            set { SetProperty(ref trackReview, value); }
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }
        private MTrack selectedTrack;
        public MTrack SelectedTrack
        {
            get { return selectedTrack; }
            set
            {
                selectedTrack = value;
                OnPropertyChanged();
            }
        }
        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan position;
        public TimeSpan Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }

        double maximum = 100f;
        public double Maximum
        {
            get { return maximum; }
            set
            {
                if (value > 0)
                {
                    maximum = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isPlaying;
        public ICommand PlayCommand => new Command(Play);
        public ICommand ChangeCommand => new Command(ChangeMusic);
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged(nameof(PlayIcon));
            }
        }
        public string PlayIcon
        {
            get => isPlaying ? "pause.png" : "play.png";
        }
        public ImageSource CoverImage { get; set; }
        public MusicPlayerVM(MTrack track, ObservableCollection<MTrack> trackList, Image coverImage)
        {
            this.trackList = trackList;
            CoverImage = coverImage?.Source;
            PlayTrack(track.TrackID);
        }
        private async void Play()
        {
            if (isPlaying)
            {
                await CrossMediaManager.Current.Pause();
                IsPlaying = false;
            }
            else
            {
                await CrossMediaManager.Current.Play();
                IsPlaying = true;
            }
        }
        private void ChangeMusic(object obj)
        {
            if ((string)obj == "P")
                PreviousTrack();
            else if ((string)obj == "N")
                NextTrack();
        }
        public string filename { get; set; }
        private async void PlayTrack(int ID)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                FileHelper.DeleteFile(filename);
            }

            SelectedTrack = await trackService.GetById<MTrack>(ID);
            await SetTrackReview(ID);
            Rating = TrackReview != null ? TrackReview.Rating : 0;
            var mediaInfo = CrossMediaManager.Current;
            filename = FileHelper.SaveFile(selectedTrack.MP3File, Guid.NewGuid() + ".mp3");

            if (!string.IsNullOrEmpty(filename))
            {
                await mediaInfo.Play(filename);

                IsPlaying = true;

                mediaInfo.MediaItemFinished += (sender, args) =>
                {
                    IsPlaying = false;
                    FileHelper.DeleteFile(filename);
                    NextTrack();
                };

                Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
                {
                    Duration = mediaInfo.Duration;
                    Maximum = duration.TotalSeconds;
                    Position = mediaInfo.Position;
                    return true;
                });

                isPlaying = true;
            }
        }
        private void NextTrack()
        {
            var currentIndex = trackList?.Select(i => i.TrackID).ToList().IndexOf(selectedTrack.TrackID);

            if (currentIndex != null && currentIndex < trackList.Count - 1)
            {
                SelectedTrack = trackList[(int)currentIndex + 1];
                PlayTrack(selectedTrack.TrackID);
            }
        }
        private void PreviousTrack()
        {
            var currentIndex = trackList?.Select(i => i.TrackID).ToList().IndexOf(selectedTrack.TrackID);

            if (currentIndex != null && currentIndex > 0)
            {
                SelectedTrack = trackList[(int)currentIndex - 1];
                PlayTrack(selectedTrack.TrackID);
            }
        }
        private async Task SetTrackReview(int TrackID)
        {
            var request = new ReviewSearchRequest()
            {
                TrackID = TrackID,
                UserID = SignedInUser.User.UserID
            };

            var list = await reviewService.Get<List<MTrackReview>>(request);
            if(list != null)
                TrackReview = list.FirstOrDefault();
        }
    }
}
