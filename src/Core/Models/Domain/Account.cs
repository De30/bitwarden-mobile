﻿using System.Collections.Generic;
using Bit.Core.Enums;
using Bit.Core.Models.Data;

namespace Bit.Core.Models.Domain
{
    public class Account : Domain
    {
        public AccountProfile Profile;
        public AccountTokens Tokens;
        public AccountSettings Settings;
        public AccountKeys Keys;

        public Account() { }
        
        public Account(AccountProfile profile, AccountTokens tokens)
        {
            Profile = profile;
            Tokens = tokens;
            Settings = new AccountSettings();
            Keys = new AccountKeys();
        }

        public Account(Account account)
        {
            // Copy constructor excludes Keys (for storage)
            Profile = new AccountProfile(account.Profile);
            Tokens = new AccountTokens(account.Tokens);
            Settings = new AccountSettings(account.Settings);
        }

        public class AccountProfile
        {
            public AccountProfile() { }

            public AccountProfile(AccountProfile copy)
            {
                if (copy == null) { return;}
                
                UserId = copy.UserId;
                Email = copy.Email;
                AuthStatus = copy.AuthStatus;
                HasPremiumPersonally = copy.HasPremiumPersonally;
                KdfType = copy.KdfType;
                KdfIterations = copy.KdfIterations;
            }
            
            public string UserId;
            public string Email;
            public AuthenticationStatus? AuthStatus;
            public bool? HasPremiumPersonally;
            public KdfType? KdfType;
            public int? KdfIterations;
        }
        
        public class  AccountTokens
        {
            public AccountTokens() {}

            public AccountTokens(AccountTokens copy)
            {
                if (copy == null) { return;}
                
                AccessToken = copy.AccessToken;
                RefreshToken = copy.RefreshToken;
            }
            
            public string AccessToken;
            public string RefreshToken;
        }
        
        public class AccountSettings
        {
            public AccountSettings() {}

            public AccountSettings(AccountSettings copy)
            {
                if (copy == null) { return;}
                
                EnvironmentUrls = copy.EnvironmentUrls;
                PinProtected = copy.PinProtected;
            }
            
            public EnvironmentUrlData EnvironmentUrls;
            public EncString PinProtected;
        }
        
        public class AccountKeys
        {
            public SymmetricCryptoKey Key;
            public string KeyHash;
            public SymmetricCryptoKey EncKey;
            public Dictionary<string, SymmetricCryptoKey> 
                OrganizationKeys = new Dictionary<string, SymmetricCryptoKey>();
            public byte[] PrivateKey;
            public byte[] PublicKey;
        }
    }
}