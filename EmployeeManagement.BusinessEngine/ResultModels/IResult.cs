﻿namespace EmployeeManagement.BusinessEngine.ResultModels
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
