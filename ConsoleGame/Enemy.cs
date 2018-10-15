namespace ConsoleGame
{
    class Enemy : GameObject
    {
        public int damage = 1;
        


        public Enemy(int x,int y) : base(x ,y)
        {

        }

        public Enemy(int x, int y, int damage) : this(x, y)
        {
            this.damage = damage;
        }
    }
}
