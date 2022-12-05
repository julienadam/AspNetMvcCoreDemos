namespace ExceptionDumpMiddleWareDemo.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    public string? DumpFile { get; set; }
}
