﻿using System;

namespace ReactiveCore.Models
{
    public class Ref<T>
    {
        private readonly Func<T> getter;
        private readonly Action<T> setter;

        public Ref(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }

        public T Value
        {
            get => getter();
            set => setter(value);
        }
    }

}
