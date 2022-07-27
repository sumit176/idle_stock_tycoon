using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class ViewHandler : MonoBehaviour
    {
        static ViewHandler mIntance;

        [SerializeField] private View[] views;
        [SerializeField] private View defaultView;

        //Holds the view type info
        private Dictionary<Type, View> viewMap = new Dictionary<Type, View>();

        //holds the current stacked views
        private Stack<View> stack = new Stack<View>();

        private void Awake()
        {
            mIntance = this;
            viewMap.Clear();
            stack.Clear();

            MapViewTypes();

            if(defaultView != null)
            {
                defaultView.Show();
                stack.Push(defaultView);
            }
        }

        private void MapViewTypes()
        {
            foreach (var item in views)
            {
                viewMap.Add(item.GetType(), item);
            }
        }

        public static T GetView<T>() where T : IView
        {
            if(mIntance.viewMap.ContainsKey(typeof(T)))
            {
                return (T)(object)mIntance.viewMap[typeof(T)];
            }
            else
            {
                Debug.LogError($"View {typeof(T).Name} does not exists! ");
                return default(T);
            }
        }

        public static View GetView(Type type)
        {
            if (mIntance.viewMap.ContainsKey(type))
            {
                return mIntance.viewMap[type];
            }
            else
            {
                Debug.LogError($"View {type.Name} does not exists! ");
                return null;
            }
        }

        public static T Show<T>(Hashtable info = null) where T : IView
        {
            var viewT = GetView<T>();
            var view = viewT as View;
            if(view != null)
            {
                view.SetInfo(info);
                view.Show();
                mIntance.stack.Push(view);
            }
            else
            {
                Debug.LogError($"View {typeof(T).Name} does not exists! ");
                return default(T);
            }
            return viewT;
        }

        public static T Push<T>(Hashtable info = null) where T : IView
        {
            if(mIntance.stack.Count > 0)
            {
                var top = mIntance.stack.Peek();
                top.Hide();
            }
            return Show<T>(info);
        }

        public static T Replace<T>(Hashtable info = null) where T : IView
        {
            ClearStacks();
            return Show<T>(info);
        }

        public static void Back()
        {
            if(mIntance.stack.Count == 0)
            {
                if(mIntance.defaultView != null && !mIntance.defaultView.pVisible)
                {
                    mIntance.defaultView.Show();
                }
                return;
            }

            //hide top
            var top = mIntance.stack.Pop();
            top.Hide();

            // show last one
            if(mIntance.stack.Count > 0)
            {
                var view = mIntance.stack.Peek();
                view.Show();
            }
        }

        private static void ClearStacks()
        {
            while (mIntance.stack.Count > 0)
            {
                var view = mIntance.stack.Pop();
                view.Hide();
            }
        }
    }
}
