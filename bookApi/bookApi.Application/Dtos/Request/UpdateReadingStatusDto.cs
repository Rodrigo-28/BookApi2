using bookApi.Domian.Enums;

namespace bookApi.Application.Dtos.Request
{
    public class UpdateReadingStatusDto
    {
        public required ReadingStatusEnum Status { get; set; }

    }
}
