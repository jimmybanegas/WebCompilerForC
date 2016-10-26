#include <stdio.h>
#include <conio.h>

int main()
{
    /*
      Declaration of variables used
    */
 
    showframe(12,25);
    printf("\nPlayer 1, enter your name:"); fgets(name[0], 30, stdin);
    printf("\nPlayer 2, enter your name:"); fgets(name[1], 30, stdin);
 
    printf("\n%s, you take 0",name[0]);
    printf("\n%s, you take X",name[1]); getch();
 
    clrscr();
 
    do
    {
       while(!enter)
       {
         if(khbit())
          ch = getch();
        
           switch(ch)
           {
             case UPARROW : box = navigate(a[3][3], box, player, UPARROW);
             .
             .
             .
           }
       }
       if(quit) break;
       //check if the player wins
       win = checkforwin(a);
    
     }while(!win)
 
    if(win)
    { .
      .
    }
 
    else if(quit)
    {    .
         .
    }
 
 return 0;
}

#include <stdio.h>

int main()
{
    FILE *fh;
    int  ch;
     
    fh = fopen("ascii.txt","r");
 
    for(i=0;i<256;i++)
     fprint(fh,"\n%d - %c",i,i);
 
    fclose(fh);
    return 0;
}

int boxesleft(char a[3][3])
{
   int i,j,boxesleft=9;

   for(i=0;i<3;i++)
    { for(j=0;j<3;j++)
      { if((a[i][j] == 'X') ||(a[i][j] == 'O'))
          boxesleft--;
      }
    }

   return boxesleft;
}

int checkforwin(char arr[3][3])
{
  int w=0;

/*  0,0   0,1   0,2
    1,0   1,1   1,2
    2,0   2,1   2,2
*/
  //rows
  if((arr[0][0] == arr[0][1]) && (arr[0][1] == arr[0][2])) w = 1;
  else if((arr[1][0] == arr[1][1]) && (arr[1][1] == arr[1][2])) w = 1;
  else if((arr[2][0] == arr[2][1]) && (arr[2][1] == arr[2][2])) w = 1;

  //coloums
  else if((arr[0][0] == arr[1][0]) && (arr[1][0] == arr[2][0])) w = 1;
  else if((arr[0][1] == arr[1][1]) && (arr[1][1] == arr[2][1])) w = 1;
  else if((arr[0][2] == arr[1][2]) && (arr[1][2] == arr[2][2])) w = 1;

  //diagonal
  else if((arr[0][0] == arr[1][1]) && (arr[1][1] == arr[2][2])) w = 1;
  else if((arr[0][2] == arr[1][1]) && (arr[1][1] == arr[2][0])) w = 1;

  return w;
}

//Function to handle the navigation
int navigate(char arr[3][3], int box, int player, int key)
{
   switch(key)
   {
     case UPARROW    : if( (box!=1) || (box!=2) || (box!=3) )
		               { box-=3; if(box<1) box = 1; gotobox(box); }
	                   break;

     case DOWNARROW  : if( (box!=7) || (box!=8) || (box!=9) )
		               { box+=3; if(box>9) box = 9; gotobox(box); }
		               break;

     case LEFTARROW  : if( (box!=1) || (box!=4) || (box!=7) )
		               { box--;  if(box<1) box = 1; gotobox(box); }
		               break;

     case RIGHTARROW : if( (box!=3) || (box!=6) || (box!=9) )
		               { box++; if(box>9) box = 9; gotobox(box); }
		               break;

     case ENTER      : if(player == 0)
			            putintobox(arr,'O',box);
		               else if(player == 1)
			            putintobox(arr,'X',box);
		               break;
    }//end of switch(key)

 return box;
}