using COMP3851B.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP3851B.BBL
{
    public class Guide
    {

        //Guide Category Properties
        public int gdeCatID { get; set; }
        public string gdeCatName { get; set; }

        //Guide Properties
        public int gdeID { get; set; }
        public string gdeTitle { get; set; }
        public string gdeDesc { get; set; }
        public string gdeThumbnail { get; set; }


        //Object
        public Guide()
        {

        }

        public Guide(string gdecatname)
        {
            this.gdeCatName = gdecatname;
        }
        public Guide(int gdecatid, string gdecatname)
        {
            this.gdeCatID = gdecatid;
            this.gdeCatName = gdecatname;
        }

        public Guide(string gdetitle, int gdecatid)
        {
            this.gdeCatID = gdecatid;
            this.gdeTitle = gdetitle;
        }

        public Guide(string gdetitle, string imagepath, int gdecatid)
        {
            this.gdeCatID = gdecatid;
            this.gdeTitle = gdetitle;
            this.gdeThumbnail = imagepath;
        }
        public Guide(int gdeid, string gdetitle, string gdedesc, string imagepath)
        {
            this.gdeID = gdeid;
            this.gdeTitle = gdetitle;
            this.gdeDesc = gdedesc;
            this.gdeThumbnail = imagepath;
        }
        public Guide(string gdetitle, string gdedesc, string imagepath, int catid)
        {
            this.gdeTitle = gdetitle;
            this.gdeDesc = gdedesc;
            this.gdeThumbnail = imagepath;
            this.gdeCatID = catid;
        }
        public Guide(int gdeid, string gdetitle, string gdedesc, string imagepath, int gdecatid, string gdecatname)
        {
            this.gdeID = gdeid;
            this.gdeTitle = gdetitle;
            this.gdeDesc = gdedesc;
            this.gdeThumbnail = imagepath;
            this.gdeCatID = gdecatid;
            this.gdeCatName = gdecatname;
        }


        //Methods
        //Category Methods
        public int AddCategory()
        {
            GuideDAO dao = new GuideDAO();
            return (dao.InsertCategory(this));
        }
        public List<Guide> GetAllCategories()
        {
            GuideDAO dao = new GuideDAO();
            return dao.GetAllGuideCategories();
        }
        public List<Guide> GetAllCategoriesOrdered()
        {
            GuideDAO dao = new GuideDAO();
            return dao.GetAllGuideCategoriesOrdered();
        }

        public Guide GetOneCategory(int id)
        {
            GuideDAO dao = new GuideDAO();
            return dao.GetOneCategory(id);
        }

        public int UpdateCategory(int id, string name)
        {
            GuideDAO dao = new GuideDAO();
            return dao.UpdateCategory(name, id);
        }

        public int DeleteCategory(int id)
        {
            GuideDAO dao = new GuideDAO();
            return dao.DeleteCategory(id);
        }

        public List<Guide> SearchFor(string substring)
        {
            GuideDAO dao = new GuideDAO();
            return dao.SearchFor(substring);
        }

        //Guide Methods
        public int AddGuide()
        {
            GuideDAO dao = new GuideDAO();
            return (dao.InsertGuide(this));
        }
        public List<Guide> GetAllGuides()
        {
           GuideDAO dao = new GuideDAO();
            return dao.GetAllGuides();
        }
        public List<Guide> GetAllByCategory(int id)
        {
            GuideDAO dao = new GuideDAO();
            return dao.GetAllByCategory(id);
        }

        public Guide GetOneGuide(int id)
        {
            GuideDAO dao = new GuideDAO();
            return dao.GetOneGuide(id);
        }

        public int UpdateGuide(int id)
        {
            GuideDAO dao = new GuideDAO();
            return dao.UpdateGuide(this, id);
        }

        public int DeleteGuide(int id)
        {
            GuideDAO dao = new GuideDAO();
            return dao.DeleteGuide(id);
        }

        public List<Guide> SearchForGuide()
        {
            GuideDAO dao = new GuideDAO();
            return dao.SearchForGuide(this);
        }
        public List<Guide> SearchUserGuide(int catid, string title)
        {
            GuideDAO dao = new GuideDAO();
            return dao.SearchUserGuide(catid, title);
        }
    }
}
