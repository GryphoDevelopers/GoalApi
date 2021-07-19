using Response.Error;
using Response.Success;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Goal.Response
{
    public static class GoalResponse
    {
        private static GetResponse response = new GetResponse();
        public static GetResponse ModelError(List<ValidationResult> result, GetResponse.Action action, string request)
        {
            return response.ModelError(result, action, request);
        }

        public static GetResponse ExceptionError(Exception exception)
        {
            return response.ExceptionError(exception);
        }

        public static GetResponse Success(string request)
        {
            return response.Success(request);
        }
    }

    public class GetResponse
    {
        public List<Error> ListError { get; set; }

        public List<Success> ListSuccess { get; set; }

        public enum Action
        {
            Insert
        }

        public GetResponse ExceptionError(Exception exception)
        {
            List<Error> list = new List<Error>();
            list.Add(new Error()
            {
                Status = 400,
                Action = exception.StackTrace,
                Message = exception.Message,
                Request = exception.Source
            });
            this.ListError = list;
            return this;
        }

        public GetResponse ModelError(List<ValidationResult> result , Action action, string request)
        {
            List<Error> list = new List<Error>();
            foreach (var message in result)
            {
                list.Add(new Error()
                {
                    Status = 400,
                    Action = action + " " + message.MemberNames.ToList().FirstOrDefault(),
                    Message = message.ErrorMessage.ToString(),
                    Request = request
                });
            }
            this.ListError = list;
            return this;
        }

        public GetResponse Success(string request)
        {
            List<Success> list = new List<Success>();
            list.Add(new Success()
            {
                Status = 200,
                Request = request
            });
            this.ListSuccess = list;
            return this;
        }

        public List<Error> GetError()
        {
            return ListError;
        }

        public List<Success> GetSuccess()
        {
            return ListSuccess;
        }
    }
}
