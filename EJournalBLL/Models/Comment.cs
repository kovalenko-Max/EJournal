using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJournalBLL;

namespace EJournalBLL.Models
{
    public class Comment: INotifyPropertyChanged
    {
        private string _comments;
        private CommentType _commentType;

        public int Id { get; set; }
        public string Comments 
        { 
            get 
            {
                return _comments;
            }
            set 
            {
                _comments = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(string.Empty));
            } 
        }
        public CommentType CommentTypeValue
        {
            get
            {
                return _commentType;
            }
            set
            {
                _commentType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
        }

        public bool IsDelete { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            return obj is Comment comments &&
                   Id == comments.Id &&
                   Comments == comments.Comments &&
                   CommentTypeValue == comments.CommentTypeValue &&
                   IsDelete == comments.IsDelete;
        }



        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Comments, CommentTypeValue, IsDelete);
        }

        public Comment()
        {
            Comments = string.Empty;
            CommentTypeValue = ((CommentType)0);
        }
    }
}
