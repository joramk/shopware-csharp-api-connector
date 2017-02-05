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
        public int id;
        public int albumId;         // see enum MediaAlbum for values
        public string name;
        public string description;
        public string path;
        public string type;
        public string extension;
        public int? userId;
        public string created;     // date/time
        public int? fileSize;

        public Media(int m_id, int m_albumId, string m_name, string m_description, string m_path, string m_type, string m_extension, int? m_userId, string m_created, int? m_fileSize)
        {
            id = m_id;
            albumId = m_albumId;
            name = m_name;
            description = m_description;
            path = m_path;
            type = m_type;
            extension = m_extension;
            userId = m_userId;
            created = m_created;
            fileSize = m_fileSize;
        }
    }  
}
