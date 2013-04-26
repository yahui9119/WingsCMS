﻿using Omu.AwesomeMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wings.Resources;

namespace Wings.UI
{
    public static class AwesomeConfigurator
    {
        public static void Configure()
        {
            Settings.Lookup.HighlightChange = true;
            Settings.MultiLookup.HighlightChange = true;

            Settings.GetText = GetTranslate;
        }

        private static string GetTranslate(string type, string key)
        {
            if (type == "Form.ConfirmOptions" && key == "Title") return "";
            if (type == "Form.ConfirmOptions" && key == "Message") return @Mui.confirm_delete;
            if (type == "PopupForm" && key == "Title") return "";
            if (type == "Lookup" && key == "Title") return "";
            if (type == "MultiLookup" && key == "Title") return "";
            switch (key)
            {
                case "CancelText": return Mui.Cancel;
                case "YesText": return Mui.Yes;
                case "NoText": return Mui.No;
                case "MoreText": return Mui.more;
                case "SearchText": return Mui.Search;
            }
            return null;
        }
    }
}