using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommonService.Navigation
{
    public class PageHistoryState
    {
        private List<string> previousPages;
        private bool isgoingback = false;

        public PageHistoryState()
        {
            previousPages = new List<string>();
        }

        /// <summary>
        /// Adding page to history only forward
        /// </summary>
        /// <param name="pageName"></param>
        public bool AddPageToHistory(string pageName)
        {
            bool ispageadded = true;

            if (!isgoingback)
            {
                previousPages.Add(pageName);
                ispageadded = true;
            }
            else
                ispageadded = false;

            isgoingback = false;

            return ispageadded;
        }

        /// <summary>
        /// Return page from stack to navigate back
        /// </summary>
        /// <returns></returns>
        public string GetGoBackPage()
        {
            if (previousPages.Count > 1)
            {
                isgoingback = true;
                // Jump first
                string pageToReturn = previousPages.ElementAt(previousPages.Count - 2);
                //Remove from stack
                previousPages.RemoveAt(previousPages.Count - 1);
                return pageToReturn;
            }

            // Can't go back because you didn't navigate enough
            return previousPages.FirstOrDefault();
        }

        /// <summary>
        /// Check can go back
        /// </summary>
        /// <returns></returns>
        public bool CanGoBack()
        {
            return previousPages.Count > 1;
        }
    }
}
