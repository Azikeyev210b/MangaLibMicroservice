﻿namespace ValueObjects.Base
{
    public interface IValidator<T>
    {
        void Validate(T value);
    }
}