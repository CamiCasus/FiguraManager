namespace Infrastructure.CrossCutting.Common
{
    public abstract class RegularExpression
    {
        public const string EnteroMayorCero = "^([0]*[1-9][0-9]*)$";
        public const string DecimalMayorCero = @"^(([0]+[.][0]*[1-9]+([0-9]*)?)|([0]*[1-9]+([0-9]*)?([.][0-9]+)?))$";
        public const string DecimalMayorIgualCero = @"^(([0]([.][0-9]+)?)|([0]+[.][0]*[1-9]+([0-9]*)?)|([0]*[1-9]+([0-9]*)?([.][0-9]+)?))$";
        public const string AlphaNumerico = @"^(([\w]+([\s][\w]+)?([\-]?))+)$";
    }
}
