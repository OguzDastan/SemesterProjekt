﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App8.Model;

namespace App8
{
    class SessionManager
    {
        private static SessionManager _myManager;
        public User loggedInUser;

        private SessionManager()
        {
        }

        public static SessionManager GetManager()
        {
            if(_myManager == null)
            {
                _myManager = new SessionManager();
            }

            return _myManager;
        }

        public bool Login(User u)
        {
            DBManager myDb = DBManager.getManager();
            List<User> users = myDb.GetUsers();

            bool UnameExist = false;
            bool PwordExist = false;

            foreach (User thisUser in users)
            {
                if (thisUser.UserName == u.UserName)
                {
                    UnameExist = true;
                }
                if (thisUser.Password == u.Password && UnameExist)
                {
                    PwordExist = true;
                }
            }

            if (UnameExist && PwordExist)
            {
                //log ind
                this.loggedInUser = DBManager.getManager().getUserByName(u.UserName);
                return true;
            }
            else if (UnameExist)
            {
                //Username Correct
                return false;
            }
            else
            {
                //username not correct
                return false;
            }
        }
    }
}
