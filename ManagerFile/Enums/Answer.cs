using CliSharp.Attributes;

namespace ManagerFile.Enums
{
    public enum Answer
    {
        [ParameterName("")]
        None,

        [ParameterName("y")]
        Yes,

        [ParameterName("n")]
        No
    }
}
