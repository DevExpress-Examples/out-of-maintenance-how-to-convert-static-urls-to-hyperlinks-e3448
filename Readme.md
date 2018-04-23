# How to convert static URLs to hyperlinks


<p>Let us assume that you have a number of documents with unformatted URLs. You can easily convert these URLs to hyperlinks by using the approach from this example. Load your document into  RichEditControl and use Search API (see <a href="https://www.devexpress.com/Support/Center/p/E3147">Search API - An example of use</a>) to find all URLs in the document. Then convert them to hyperlinks by using the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraRichEditAPINativeSubDocument_CreateHyperlinktopic862"><u>SubDocument.CreateHyperlink Method</u></a> (see also: <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument7397"><u>Hyperlinks and Bookmarks</u></a>).</p><p>Please note that starting with version v2011 vol 1 the XtraRichEdit Suite has the <a href="http://www.devexpress.com/Products/NET/Controls/WinForms/Rich_Editor/auto_correct.xml"><u>AutoCorrect feature</u></a> that allows you to convert URLs to hyperlinks as you type.</p>

<br/>


