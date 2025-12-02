namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class CreateFlagHandleResponse
    {
        public int FlagId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}