namespace Application.Core
{
    public class TimeZoneDto
    {
        #region Constructor

        public TimeZoneDto()
            : this(string.Empty, 0)
        {
        }

        public TimeZoneDto(string id)
            : this(id, 0)
        {
        }

        public TimeZoneDto(int gmt)
            : this(string.Empty, gmt)
        {
        }

        public TimeZoneDto(string id, int gmt)
        {
            Id = id;
            Gmt = gmt;
        }

        #endregion

        #region Propiedades

        public string Id { get; set; }

        public int Gmt { get; set; }

        #endregion
    }
}
