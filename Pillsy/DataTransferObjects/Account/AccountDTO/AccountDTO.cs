﻿using Pillsy.Enum.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pillsy.DataTransferObjects.Account.AccountDTO
{
    public class AccountDTO
    {
        public Guid AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountRole Role { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountStatus Status { get; set; }
    }
}
