namespace HW1
{
    public class BSTNode 
    {
        public int data; // private fields 
        public BSTNode left;
        public BSTNode right;

        // constructor 
        public BSTNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
        // properties
        //public int Data
        //{
        //    get {return this.data; }
        //    set {this.data = value; }

        //}
        //public BSTNode Left
        //{
        //    get {return this.left; }
        //    set {this.left = value; }
        //}
        //public BSTNode Right
        //{
        //    get { return this.right;}
        //    set { this.right = value; }
        //}
    }
}