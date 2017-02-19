using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Images
{
    public enum MediaAlbum { PapierKorb=-13, Hersteller, Blog, Unsortiert, Sonstiges, Musik, Video, Dateien, Newsletter, Aktionen, Einkaufswelten, Banner, Artikel};

    public class Media
    {
        public int? id;
        public int? albumId;         // see enum MediaAlbum for values
        public string name;
        public string description;
        public string path;
        public string type;
        public string extension;
        public int? userId;
        public string created;      // date/time
        public int? fileSize;

        // additional fields used for creating media
        public int? album;          // required: instead of albumId
        public string file;         // required: path to the file that should be uploaded
    }  
}
