using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

namespace SOLVERS.DATA
{
    [Serializable]
    public class UserData
    {
        public string handle;
        public string bio;
        public string badgeId;
        public string backgroundId;
        public string profileImageUrl;
        public int solvedCount;
        public int voteCount;
        public int tier;
        public int rating;
        public int ratingByProblemsSum;

        public int ratingByClass;
        public int ratingBySolvedCount;
        public int ratingByVoteCount;

        [JsonProperty("class")]
        public int userClass;

        public string classDecoration;
        public int rivalCount;
        public int reverseRivalCount;
        public int maxStreak;
        public int coins;

        public int stardusts;
        public string joinedAt;
        public string bannedUntil;
        public string proUntil;
        public int rank;

        public bool isRival;
        public bool isReverseRival;
    }
}