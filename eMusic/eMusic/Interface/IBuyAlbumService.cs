using eMusic.Model;
using eMusic.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Interface
{
    public interface IBuyAlbumService
    {
        Task<List<MBuyAlbum>> Get(BuyAlbumSearchRequest search);
        Task<MBuyAlbum> GetById(int ID);
        Task<MBuyAlbum> Insert(BuyAlbumRequest request);
        Task<MBuyAlbum> Update(int ID, BuyAlbumRequest request);
        Task<bool> Delete(int ID);
    }
}
