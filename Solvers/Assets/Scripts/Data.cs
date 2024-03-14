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

    public class ProblemData
    {
        public ProblemData(int problemId, string titleKo, string rank, string date ) 
        { 
            this.problemId = problemId; 
            this.titleKo = titleKo; 
            this.rank = rank; 
            this.date = date; 
        }

        public int problemId;
        public string titleKo;
        public string rank;
        public string date;
    }

    public enum ORDER 
    {
        DELETEROW,
        INSERTROW,
        CHANGEROW
    }

    public class BaseOrder
    {
        public BaseOrder(string sheetName, string type) { this.sheetName = sheetName; this.type = type; }

        public string sheetName;
        public string type;
    }

    [Serializable]
    public class DeleteRowOrder : BaseOrder
    {
        public DeleteRowOrder(string sheetName, string lable, string value) : base(sheetName, ORDER.DELETEROW.ToString())
        {
            this.lable = lable;
            this.value = value;
        }

        public string lable;
        public string value;
    }

    [Serializable]
    public class ChangeRowOrder : BaseOrder
    {
        public ChangeRowOrder(string sheetName, string lable, string beforeValue, string afterValue) : base(sheetName, ORDER.CHANGEROW.ToString())
        {
            this.lable = lable;
            this.beforeValue = beforeValue;
            this.afterValue = afterValue;
        }

        public string lable;
        public string beforeValue;
        public string afterValue;
    }

    [Serializable]
    public class InsertRowOrder : BaseOrder
    {
        public InsertRowOrder(string sheetName, int index, string title, string writer, string url, string detail) : base(sheetName, ORDER.INSERTROW.ToString())
        {
            this.index = index;
            this.title = title;
            this.writer = writer;
            this.url = url;
            this.detail = detail;
        }

        public int index;
        public string title;
        public string writer;
        public string url;
        public string detail;
    }
}