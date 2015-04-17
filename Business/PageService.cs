using System;
using System.Linq;
using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using log4net;
using EPiCenterBaseProject.Business.Interfaces;
using EPiCenterBaseProject.Models.Pages;

namespace EPiCenterBaseProject.Business
{
    public class PageService : IPageService
    {
        private readonly IContentRepository _repository;
        private readonly UrlResolver _urlResolver;
        private static readonly ILog Log = LogManager.GetLogger(typeof(PageService));

        public PageService(IContentRepository repository, UrlResolver urlResolver)
        {
            _repository = repository;
            _urlResolver = urlResolver;
        }

        public StartPage GetStartPage()
        {
            return _repository.Get<StartPage>(ContentReference.StartPage);
        }

        public bool IsStartPage(PageData currentPage)
        {
            return (currentPage.ContentTypeID.Equals(GetStartPage().ContentTypeID));
        }

        public string GetFriendlyUrl(PageData page)
        {
            if (page == null)
            {
                return String.Empty;
            }

            return GetFriendlyUrl(page.ContentLink, page.LanguageBranch);
        }

        public string GetFriendlyUrl(ContentReference reference, string language = null)
        {
            var url = "#";
            try
            {
                if (ContentReference.IsNullOrEmpty(reference))
                {
                    return String.Empty;
                }

                // http://joelabrahamsson.com/episerver-7-and-mvc-getting-the-url-for-a-page/
                url = _urlResolver.GetUrl(reference, language);
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetFriendlyUrl", ex);
            }
            return url;
        }

        public string GetFriendlyUrlByPageId(int pageId)
        {
            if (pageId <= 0)
            {
                return String.Empty;
            }
            var contentPageRef = new PageReference(pageId);
            var isPageExists = PermanentLinkMapStore.Find(contentPageRef);
            return isPageExists == null ?
                string.Empty :
                GetFriendlyUrl(contentPageRef);
        }

        public string GetFriendlyUrlFromLinkUrl(string linkUrl)
        {
            try
            {
                var relativeUrl = new Url(linkUrl);
                var pageId = relativeUrl.QueryCollection.Get("id");
                var lang = relativeUrl.QueryCollection.Get("epslanguage");
                if (!String.IsNullOrEmpty(pageId))
                {
                    var pageReference = new PageReference(pageId);
                    return GetFriendlyUrl(pageReference, lang);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in GetFriendlyUrlFromLinkUrl", ex);
            }
            return linkUrl;
        }

        public string ConvertUrlToExternal(PageData pageData = null, PageReference p = null)
        {
            if (pageData == null && p == null)
            {
                return string.Empty;
            }
            var page = pageData ?? _repository.Get<PageData>(p);

            var pageUrlBuilder = new UrlBuilder(page.LinkURL);

            Global.UrlRewriteProvider.ConvertToExternal(pageUrlBuilder, page.PageLink, Encoding.UTF8);

            string pageURL = pageUrlBuilder.ToString();

            UriBuilder uriBuilder = new UriBuilder(SiteDefinition.Current.SiteUrl);

            uriBuilder.Path = pageURL;
            var jj = ServiceLocator.Current.GetInstance<UrlResolver>().GetUrl(p);
            if (uriBuilder.Path == "/")
                return uriBuilder.Uri.AbsoluteUri;

            string[] words = uriBuilder.Uri.AbsoluteUri.Split(new char[] {':', '/', '.'},
                        StringSplitOptions.RemoveEmptyEntries);
            bool reoccurs = words.Count(q => q == "http") > 1;

            if (reoccurs)
                return uriBuilder.Uri.LocalPath.StartsWith("/") ? uriBuilder.Uri.LocalPath.Remove(0,1) : uriBuilder.Uri.LocalPath;

            return uriBuilder.Uri.AbsoluteUri;
        }

        public PageReference GetNewsListPageRef()
        {
            var startPage = GetStartPage();
            if (ContentReference.IsNullOrEmpty(startPage.NewsListContainer))
            {
                Log.Error("ProductPageTemplate has no value");
            }
            return startPage.NewsListContainer;
        }

   
    }
}