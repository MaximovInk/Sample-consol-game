# Simple consol game

The program already has an example.

## Getting Started

1. Create new Level

```
Level level = new Level(width, height);
```
or
```
Level level = new Level(width, height, new Finish(width,height));
```
2. Create player
```
Player player = new Player(pos x, pos y);
```
or
```
Player player = new Player(pos x, pos y, color, color, symbol);
```
3. Add objects [optionally]
```
GameObject obj = new GameObject(x,y, widht, height , is can contact, symbol, color, background color );
level.AddObject(obj);
```
4.Enemies
```
Enemy enemy = new Enemy(pos x, pos y , damage);
MovedEnemy m_enemy = new MovedEnemy(pos x , pos y, move interval, way points );
level.AddObject(obj);
```

5. Add input
```
Play();
```

## License

This project is licensed under the GNU v3 License - see the [LICENSE](LICENSE) file for details
