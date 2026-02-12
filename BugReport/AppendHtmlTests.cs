using fm.Extensions.Testing;
using Syncfusion.DocIO.DLS;

namespace BugReport;

[TestClass]
public sealed class AppendHtmlTests
{
    [TestMethod]
    public void StyleFailTest()
    {
        const string xHtml = "<html><head /><body><style>Fails if ANYTHING is in here</style></body></html>";

        using WordDocument document = new WordDocument();
        IWParagraph? paragraph = document.AddSection().AddParagraph();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => paragraph.AppendHTML(xHtml))
            .Message.ShouldBe("""
                              startIndex ('4294967295') must be less than or equal to '34'. (Parameter 'startIndex')
                              Actual value was 4294967295.
                              """,
                "This SHOULD NOT throw an exception.");
    }
}