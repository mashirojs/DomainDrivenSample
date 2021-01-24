﻿namespace Application.Users.DataTransfers
{
    public class UserData
    {
        public UserData(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Id { get; }
        public string Name { get; }
    }
}