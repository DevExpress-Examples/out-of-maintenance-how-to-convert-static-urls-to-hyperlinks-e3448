<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128609539/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3448)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to convert static URLs to hyperlinks


<p>Let us assume that you have a number of documents with unformatted URLs. You can easily convert these URLs to hyperlinks by using the approach from this example. Load your document into  RichEditControl and use Search API (see <a href="https://www.devexpress.com/Support/Center/p/E3147">Search API - An example of use</a>) to find all URLs in the document. Then convert them to hyperlinks by using the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.API.Native.HyperlinkCollection.Create.overloads"><u>SubDocument.Hyperlinks.Create</u></a> method (see also: <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument7397"><u>Hyperlinks and Bookmarks</u></a>).</p><p>Please note that starting with version v2011 vol 1 the XtraRichEdit Suite has the <a href="https://docs.devexpress.com/WindowsForms/9890/controls-and-libraries/rich-text-editor/autocorrect"><u>AutoCorrect feature</u></a> that allows you to convert URLs to hyperlinks as you type.</p>

<br/>


