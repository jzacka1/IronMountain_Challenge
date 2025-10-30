using Iron_Mountain_Coding_Challenge.Models;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public interface IMessageProvider
    {
        ApplicationMessages Messages { get; }
    }
}
