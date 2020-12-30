using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.API.Native;
using System.Collections.Generic;

namespace RichEditConvertStaticUrlsToHyperlinks {
    public partial class Form1 : Form {
        private static Regex urlRegex = new Regex(@"((?:[a-z][\w-]+:(?:/{1,3}|[a-z0-9%])|www\d{0,3}[.]|ftp[.]|[a-z0-9.\-]+[.][a-z]{2,4}/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’]))", 
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\..\..\test.rtf";
            richEditControl1.LoadDocument(path);
        }

        private void richEditControl1_DocumentLoaded(object sender, EventArgs e) {
            CreateHyperlinks();
        }

        private bool RangeHasHyperlink(DocumentRange documentRange) {
            foreach (Hyperlink h in richEditControl1.Document.Hyperlinks) {
                if (documentRange.Contains(h.Range.Start))
                    return true;
            }

            return false;
        }
        void CreateHyperlink(DocumentRange range)
        {
            if (RangeHasHyperlink(range))
                return;

            Document doc = richEditControl1.Document;
            Hyperlink hyperlink = doc.Hyperlinks.Create(range);
            hyperlink.NavigateUri = doc.GetText(hyperlink.Range);
        }
        bool IsValidUri(IRegexSearchResult result)
        {
            try
            {
                return result.FindNext();
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private void CreateHyperlinks()
        {
            Document doc = richEditControl1.Document;

            doc.BeginUpdate();
            IRegexSearchResult result;
            result = doc.StartSearch(urlRegex);
            while (IsValidUri(result))
            {
                DocumentRange wordRange = result.CurrentResult;
                if (!RangeHasHyperlink(wordRange))
                    CreateHyperlink(wordRange);
            }

            doc.EndUpdate();
        }

    }
}