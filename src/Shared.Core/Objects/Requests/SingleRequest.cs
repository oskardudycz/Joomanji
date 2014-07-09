﻿using FluentValidation.Attributes;
using Shared.Core.Objects.DTO;
using Shared.Core.Validation.Validators;
using System.Runtime.Serialization;

namespace Shared.Core.Objects.Requests
{
    /// <summary>
    /// Class to send single record from service.
    /// Allows checkings of not null Item and inner data contract validation
    /// </summary>
    [DataContract]
    [Validator(typeof(SingleRequestValidator<>))]
    public class SingleRequest<T> : RequestBase, ISingleRequest<T>
    {
        /// <summary>
        /// Record
        /// </summary>
        [DataMember]
        public T Item { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">record</param>
        private SingleRequest(T item)
        {
            Item = item;
        }

        /// <summary>
        /// Creation metod of class object
        /// </summary>
        /// <param name="item">Record</param>
        /// <returns></returns>
        public static SingleRequest<T> Create(T item)
        {
            return new SingleRequest<T>(item);
        }

        object ISingleRequest.Item
        {
            get { return Item; }
            set { Item = (T)value; }
        }
    }
}