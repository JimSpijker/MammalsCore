using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Context.Interfaces;
using DAL.Repositories;
using Logic.Interfaces;
using Models;

namespace Logic
{
    class UserLogic : IUserLogic
    {
        private readonly UserRepository repository;

        public UserLogic(UserContext context)
        {
            repository = new UserRepository(context);
        }
        
    }
}
