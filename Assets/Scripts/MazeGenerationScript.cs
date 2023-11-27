using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerationScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(5,500)]
    public int mazeWidth=5,mazeHeight=5;        //Dimensions of maze
    public int startX,startY;                   //Position of our algo to start
    MazeCell[,] maze;                           //An array of maze cell representing the maze grid
    Vector2Int currentCell;                     //Maze Cell we are currently lookin at
    public MazeCell[,] GetMaze()
    {
        maze=new MazeCell[mazeWidth,mazeHeight];
        for(int x=0;x<mazeWidth;x++)
        {
            for(int y=0;y<mazeHeight;y++)
            {
                maze[x,y]=new MazeCell(x,y);
            }
        }
        CarvePath(startX,startY);
        return maze;
    }
    List<Direction> directions=new List<Direction>{
    Direction.Up,Direction.Down,Direction.Left,Direction.Right,
    };

    List<Direction> GetRandomDirections() {
        //Make copy of our Directions list
        List<Direction> dir=new List<Direction>(directions);

        List<Direction> rndDir=new List<Direction>();

        while(dir.Count>0){//Loop until our rndDir list is empty
            int rnd=Random.Range(0,dir.Count);//Get Random index in List
            rndDir.Add(dir[rnd]);//Add the Random direction to our list
            dir.RemoveAt(rnd);//Remove the direction so we cant choose again
        }
        //when we have all 4 directions
        return rndDir;
    }
    Vector2Int CheckNeighbours (){
        List<Direction> rndDir=GetRandomDirections();
    for(int i=0;i<rndDir.Count;i++){
        //Set neighbour coordinates to current cell for now
        Vector2Int neighbour=currentCell;
        //modify neighbour coordinates based on the random directions we are currently trying.
        switch(rndDir[i]){
            case Direction.Up:
            {
                neighbour.y++;
                break;
            }
            case Direction.Down:
            {
                neighbour.y--;
                break;
            }
            case Direction.Right:
            {
                neighbour.x++;
                break;
            }
            case Direction.Left:
            {
                neighbour.x--;
                break;
            }
        }
        if(IsCellValid(neighbour.x,neighbour.y)){
            return neighbour;
        }
        }
        return currentCell;
    }

     bool IsCellValid(int x, int y)
    {
        if(x<0 || y<0 || x>mazeWidth-1 || y>mazeHeight-1 || maze[x,y].visited )
        {
            return false;
        }
        else{
            return true;
        }
    }

    void BreakWalls(Vector2Int primaryCell, Vector2Int secondaryCell)
    {
        if(primaryCell.x>secondaryCell.x){
            //primary cell left wall
            maze[primaryCell.x,primaryCell.y].leftWall=false;
        }
        else if(primaryCell.x<secondaryCell.x){
            maze[secondaryCell.x,secondaryCell.y].leftWall=false;
        }
        else if(primaryCell.y<secondaryCell.y){
            //primary cell left wall
            maze[primaryCell.x,primaryCell.y].topWall=false;
        }
        else if(primaryCell.y>secondaryCell.y){
            maze[secondaryCell.x,secondaryCell.y].topWall=false;
        }
    }

void CarvePath(int x, int y){
    if(x<0||y<0||x>mazeWidth-1||y>mazeHeight-1){
        x=y=0;
        Debug.LogWarning("Starting position is out of bounds, defaulting to 0,0");

    }

    currentCell=new Vector2Int(x,y);
    List<Vector2Int> path=new List<Vector2Int>();

    bool deadEnd=false;
    while(!deadEnd){
        Vector2Int nextCell= CheckNeighbours();
        if(nextCell==currentCell)
        {
            for(int i=path.Count-1;i>=0;i--){
                currentCell=path[i];
                path.RemoveAt(i);
                nextCell=CheckNeighbours();

                if(nextCell!=currentCell){
                    break;
                }
            }
            if(nextCell==currentCell)
            {
                deadEnd=true;
            }
        }else{
            BreakWalls(currentCell,nextCell);
            maze[currentCell.x,currentCell.y].visited=true;
            currentCell=nextCell;
            path.Add(currentCell);
        }
    }
}


}
public enum Direction{Up,Down,Left,Right}
public class MazeCell{
    public bool visited;
    public int x,y;

    public bool topWall;
    public bool leftWall;


//Return x and y as vector2Int for convenience sake
    public Vector2Int position{
        get{
            return new Vector2Int(x,y);
        }
    }

    public MazeCell(int x,int y){
        //Coordinates of this cell in the maze grid
        this.x=x;
        this.y=y;

        //Whether the algo has visited the cell or not
        visited=false;

        //All wals are present unitl the algo removes them
        topWall=leftWall=true;
    }

}
