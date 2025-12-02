namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class UpdateFlagHandleResponse
    {
        public int FlagId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}