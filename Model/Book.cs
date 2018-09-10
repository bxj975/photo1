using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Book
    {
        /*名称*/
        private string _bookName;
        public string bookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }
        
        /*联系人*/
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        
        /*类别*/
        private int _bookType;
        public int bookType
        {
            get { return _bookType; }
            set { _bookType = value; }
        }

        /*地区*/
        private int _area;
        public int area
        {
            get { return _area; }
            set { _area = value; }
        }

        /*归属人*/
        private int _clerk;
        public int clerk
        {
            get { return _clerk; }
            set { _clerk = value; }
        }

        /*邮箱*/
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /*QQ*/
        private string _qq;
        public string qq
        {
            get { return _qq; }
            set { _qq = value; }
        }

        /*手机*/
        private string _move;
        public string move
        {
            get { return _move; }
            set { _move = value; }
        }
        /*电话*/
        private string _tele;
        public string tele
        {
            get { return _tele; }
            set { _tele = value; }
        }

        /*微信*/
        private string _weixin;
        public string weixin
        {
            get { return _weixin; }
            set { _weixin = value; }
        }
       
        /*地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*网址*/
        private string _www;
        public string www
        {
            get { return _www; }
            set { _www = value; }
        }

        /*编号*/
        private int _barcode;
        public int barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        /*图片*/
        private byte[] _bookPhoto;//数据类型重点
        public byte[] bookPhoto
        {
            get { return _bookPhoto; }
            set { _bookPhoto = value; }
        }

        /*备注*/
        private string _note;
        public string note
        {
            get { return _note; }
            set { _note = value; }
        }

        /*日期*/
        private DateTime _publishDate = DateTime.Now ;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
