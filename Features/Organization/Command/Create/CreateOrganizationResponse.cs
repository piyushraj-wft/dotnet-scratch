using System.Net;

public class CreateOrganizationResponse
{
    public bool Success { get; set; } = true;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string? Message { get; set; }
}