
using System;

namespace Core.UI
{
    public interface IAnimBehaviour
    {
        public void In(IView view, Action callback);
        public void Out(IView view, Action callback);
    }
}
