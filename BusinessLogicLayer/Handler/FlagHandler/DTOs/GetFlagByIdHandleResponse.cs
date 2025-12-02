namespace BusinessLogicLayer.Handler.FlagHandler.DTOs
{
    public class GetFlagByIdHandleResponse
    {
        public int FlagId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}