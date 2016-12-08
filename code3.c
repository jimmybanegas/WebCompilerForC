<!DOCTYPE html>
<html>
<head>
<title>Page Title</title>
</head>
<body>
<div>
<h1>This is a Heading</h1>
<p>This is a paragraph.</p>

<%  


int myArray[10] = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

int main()                            /* Most important part of the program!  */
{
    int age;                          /* Need a variable... */

    printf( "Please enter your age" );  /* Asks for age */
    scanf( "%d", &age );                 /* The input is put in age */
    if ( age < 100 ) {                  /* If the age is less than 100 */
        printf ("You are pretty young!\n" ); /* Just to show you it works... */
    }
    else if ( age == 100 ) {            /* I use else just to show an example */
        printf( "You are old\n" );
    }
    else {
        printf( "You are really old\n" );     /* Executed if no other statement is */
    }
  return 0;
}

 int DoSomethingNice( int aVariable, int aFunction, void *dataPointer )
 {
     int rv = 0;

     if (aVariable < THE_BIGGEST) {
        rv = aFunction(aVariable, dataPointer );
      } else {

        rv = aFunction(aVariable, dataPointer );
     }

     return rv;
 }

//  typedef struct {
//      int    colorSpec;
//      char   *phrase;
//  } DataINeed;

 int TalkJive( int myNumber, void *someStuff )
 {
     /* recast void * to pointer type specifically needed for this function */
     int *myData = someStuff;
     /* talk jive. */
     return 5;
 }

 int FunctTwo( int *pStruct, int *mValue )
 {
    int j;
    long  AnArray[25];
    long *pAA;

    pAA = &AnArray[13];
    j = FunctOne( pStruct, *mValue, pAA );
    return j;
 }

 float A[6][8];
 float *pf;
 pf = &A[0][0];
 //*(pf+1) = 1.3;   /* assigns 1.3 to A[0][1] */
 //*(pf+8) = 2.3;   /* assigns 2.3 to A[1][0] */


  long  myArray[20];
 long  *pArray;
 int  i;

 /* Assign values to the entries of myArray */
 pArray = myArray;
 for (i=0; i<10; ++i) {
   *pArray++ = 5 + 3*i + 12*i*i;
   *pArray++ = 6 + 2*i + 7*i*i;
 }

 float  linearA[30];
 float *A[6];

 A[0] = linearA;              /*  5 - 0 = 5 elements in row  */
 A[1] = linearA + 5;          /* 11 - 5 = 6 elements in row  */
 A[2] = linearA + 11;         /* 15 - 11 = 4 elements in row */
 A[3] = linearA + 15;         /* 21 - 15 = 6 elements        */
 A[4] = linearA + 21;         /* 25 - 21 = 4 elements        */
 A[5] = linearA + 25;         /* 30 - 25 = 5 elements        */

 *A[3][2] = 3.66;          /* assigns 3.66 to linearA[17];     */
 *A[3][3] = 1.44;         /* refers to linearA[12];
                             negative indices are sometimes useful. But avoid using them as much as possible. */



float KrazyFunction( int *parm1, int p1size, int bb )
 {
   int ix; //declaring an integer variable//
   for (ix=0; ix<p1size; ix++) {
      if (parm1[ix].m_aNumber == bb )
          return parm1[ix].num2;
   }
   return 0;
 }

 /* ... */
 //struct MyStruct myArray[4];
 //#define MY_ARRAY_SIZE (sizeof(myArray)/sizeof(*myArray))
 float v3;
 //struct MyStruct *secondArray;
 int   someSize;
 int   ix;
 /* initialization of myArray ... */
 v3 = KrazyFunction( myArray, MY_ARRAY_SIZE, 4 );
 /* ... */
 //secondArray = calloc( someSize, sizeof(myArray) );
 for (ix=0; ix<someSize; ix++) {
     secondArray[ix].m_aNumber = ix *2;
     secondArray[ix].num2 = 304 * ix * ix;
 }


 int   c, d;
 int   *pj;
//  struct MyStruct astruct;
//  struct MyStruct *bb;

 c   = 10;
 pj  = &c;             /* pj points to c */
 d   = *pj;            /* d is assigned the value to which pj points, 10 */
 pj  = &d;             /* now points to d */
 *pj = 12;             /* d is now 12 */

 bb = &astruct;
 (*bb).m_aNumber = 3;  /* assigns 3 to the m_aNumber member of astruct */
 bb->num2 = 44.3;      /* assigns 44.3 to the num2 member of astruct   */
 *pj = bb->m_aNumber;  /* eqivalent to d = astruct.m_aNumber;          */

int   myInt;
 int  *pPointer;
// struct MyStruct   dvorak;
// struct MyStruct  *pKeyboard;

 pPointer = &myInt;
 pKeyboard = &dvorak;

struct MyStruct {
     int   m_aNumber;
     float num2;
 };

int main()
{
     int *pJ2;
    // struct MyStruct *pAnItem;
}

long  *  var1, var2;
int   ** p3;

void copy_array(float *src, float *dst, int n)
{
    while (n-- > 0) {
 // Loop that counts down from n to zero
        *dst++ = *src++;   // Copies element *(src) to *(dst),
                           //  then increments both pointers
    }
}

#include "stdio.h"
const char x = 'x';
c <<=  2;

int  i, j , k;

x = a * b - c ;
y = b / c * a ;
z = a - b / c + d;

head.x=25;

head->y=20;

head.direction=RIGHT;

bool x= !true;

int main ()
{
        float a, b, c, x, y, z;
        a = 9;
        b = 12;
        c = 3;
        x = a - b / 3 + c * 2 - 1;
        y = a - b / (3 + c) * (2 - 1);
        z = a - ( b / (3 + c) * 2) - 1;
        printf ("x = %fn",x);
        printf ("y = %fn",y);
        printf ("z = %fn",z);
}

int a =2;

int mult (int x, int y)
{
  return x * y;
}

int main () {

   /* local variable definition */
   int a = 100;

   /* check the boolean condition */
   if( a == 10 ) {
      /* if condition is true then print the following */
      printf("Value of a is 10\n" );
   }
   else if( a == 20 ) {
      /* if else if condition is true */
      printf("Value of a is 20\n" );
   }
   else if( a == 30 ) {
      /* if else if condition is true  */
      printf("Value of a is 30\n" );
   }
   else {
      /* if none of the conditions is true */
      printf("None of the values is matching\n" );
   }

   printf("Exact value of a is: %d\n", a );

   return 0;
}

void swap(int a, int b)
{
    int tmp;
    tmp = a;
    a = b;
    b = tmp;
    printf(" \nvalues after swap m = %d\n and n = %d", a, b);
}

int max(int num1, int num2) {

   /* local variable declaration */
   int result;

   if (num1 == num2)
      result = num1;
   else
      result = num2;

   return result;
}


   /* check the boolean condition */
   if( a < 20 ) {
      /* if condition is true then print the following */
      printf("a is less than 20\n" );
   }
   else {
      /* if condition is false then print the following */
      printf("a is not less than 20\n" );
   }

 for( a = 10; a < 20; a = a + 1 ){
      //printf("value of a: %d\n", a);
      result = num1;
 }


int main () {

   int a;

   /* for loop execution */
   for( a = 10; a < 20; a = a + 1 ){
      printf("value of a: %d\n", a);
   }

   return 0;
}

if(boolean_expression ) {
   /* Executes when the boolean expression 1 is true */
}
else if( boolean_expression ) {
   /* Executes when the boolean expression 2 is true */
}
else if( boolean_expression ) {
   /* Executes when the boolean expression 3 is true */
}
else  {
   /* executes when the none of the above condition is true */
}

int *length;
int bend_no;
int a[5] ;
//int myArray[10] = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

 int len [] [10] ;
 //int len2 [] = {4};
 int a[][2];
 int a[5] ;

char key;

int  i, j , k;
char   c;
float  f, salary;
double d;

 int a[5][2];

 enum colors {RED=1, YELLOW, GREEN=6, BLUE };

//const int a =2;
int a =2;
int d = 3, f = 5;           // definition and initializing d and f.
const char x = 'x';               // the variable x has the value 'x'.

/* function returning the max between two numbers */
int max(int num1, int num2) {

   /* local variable declaration */
   int result;

   if (num1 == num2)
      result = num1;
   else
      result = num2;

   return result;
}

void record(){
    int x;
}

int life;

void Delay(long car){
    int c;
}

void gotoxy(int x, int y){

}

int Scoreonly(){
    int z;
}

struct coordinate{
    int x;
    int y;
    int direction;
};

for (string item : someList) {
    char key;

    Print();

   // system("cls");
    loaduno(key);
}

int main () {

   /* local variable definition */
   int a = 10;

   /* while loop execution */
   while( a < 20 ) {
      printf("value of a: %d\n", a);
      //a++;
       int tmp;
   }

   return 0;
}

int main () {

   /* local variable definition */
   int a = 10;

   /* do loop execution */
   do {
      printf("value of a: %d\n", a);
      a = a + 1;
   }while( a < 20 );

   return 0;
}


int main()
{
  int x;

  x = 0;
  do {
    /* "Hello, world!" is printed at least one time
      even though the condition is false */
      printf( "Hello, world!\n" );
  } while ( x != 0 );
  getchar();
}

int main () {

   /* local variable definition */
   char grade = 'B';

   switch(grade) {
      case 'A' :
         printf("Excellent!\n" );
         break;
      case 'B' :
      case 'C' :
         printf("Well done\n" );
         break;
      case 'D' :
         printf("You passed\n" );
         break;
      case 'F' :
         printf("Better try again\n" );
          char grade = 'B';
         break;
      default :
         printf("Invalid grade\n" );
   }

   printf("Your grade is  %c\n", grade );

   return 0;
}

while (true)
{
    take_turn(player1);
    take_turn(player2);
}

take_turn(uno,dos,tres);

while(true)
{
    if (someone_has_won() || someone_wants_to_quit() == TRUE)
    {break;}
    take_turn(player1);
    if (someone_has_won() || someone_wants_to_quit() == TRUE)
    {break;}
    take_turn(player2);
}

a= suma();
b=suma(x,y);


int main() {

   int rad;
   float PI = 3.14, area, ci;

   printf("\nEnter radius of circle: ");
   scanf("%d", &rad);

   area = PI * rad * rad;
   printf("\nArea of circle : %f ", area);

   ci = 2 * PI * rad;
   printf("\nCircumference : %f ", ci);

   return (0);
}

int main () {

   /* local variable definition */
   int a = 100;
   int b = 200;

   /* check the boolean condition */
   if( a == 100 ) {

      /* if condition is true then check the following */
      if( b == 200 ) {
         /* if condition is true then print the following */
         printf("Value of a is 100 and b is 200\n" );
      }
   }

   printf("Exact value of a is : %d\n", a );
   printf("Exact value of b is : %d\n", b );

   return 0;
}

int main () {

   /* local variable definition */
   int a = 100;
   int b = 200;

   switch(a) {

      case 100:
         printf("This is part of outer switch\n", a );
         switch(b) {
            case 200:
               printf("This is part of inner switch\n", a );
         }
   }

   printf("Exact value of a is : %d\n", a );
   printf("Exact value of b is : %d\n", b );

   return 0;
}

int main() {

   const int  LENGTH = 10;
   const int  WIDTH = 5;
   const char NEWLINE = '\n';
   int area;

   area = LENGTH * WIDTH;
   printf("value of area : %d", area);
   printf("%c", NEWLINE);

   return 0;
}

int main () {

   int n[ 10 ]; /* n is an array of 10 integers */
   int i,j;

   /* initialize elements of array n to 0 */
   for ( i = 0; i < 10; i ) {
      n[ i ] = i + 100; /* set element at location i to i + 100 */
   }

   /* output each array element's value */
   for (j = 0; j < 10; j) {
      printf("Element[%d] = %d\n", j, n[j] );
   }

   return 0;
}


int main () {

   int n[ 10 ]; /* n is an array of 10 integers */
   int i,j;

   /* initialize elements of array n to 0 */
   for ( i = 0; i < 10; i ) {
      n[ i ] = i + 100; /* set element at location i to i + 100 */
   }

   /* output each array element's value */
   for (j = 0; j < 10; j) {
      printf("Element[%d] = %d\n", j, head.hoja );
   }

   return 0;
}

// Sum the elements of an array
float sum_elements(float arr, int n)
{
    float  sum = 12.4;
    int    i =   0;

    while (i < n){
        sum += arr[i++];    // Post-increment of i, which steps
                            //  through n elements of the array
    }

    return sum;
}

int main()
{
           int i=0;
           while(i++ < 5 )
           {
                printf("%d ",i);
           }
           return 0;
}

int main()
{
     int i=1;
     while(i<10)
     {
         printf("%d ",i);
         i++;
     }
}

int main()
{
    int i=20;
    while(i>10)
    {
         printf("%d ",i);
         i--;
    }
}



int main()
{
           int i=10;
           while(--i > 5 )
           {
                printf("%d ",i);
           }
           return 0;
}

int main()
{
           int i=10;
           while(i-- > 5 )
           {
                printf("%d ",i);
           }
           return 0;
}

void swap(int *a, int *b)
{
    int tmp;
    tmp = *a;
    *a = *b;
    *b = tmp;
    printf("\n values after swap a = %d \nand b = %d", *a, *b);
}

int main()
{
    int num = 45 , *ptr , **ptr2ptr ;
    ptr     = &num;
    ptr2ptr = &ptr;

    printf("%d",**ptr2ptr);

    return(0);
}

void main() {
    int*    x;  // Allocate the pointers x and y
    int*    y;  // (but not the pointees)

    //x = malloc(sizeof(int));    // Allocate an int pointee,
                                // and set x to point to it

    *x = 42;    // Dereference x to store 42 in its pointee

    *y = 13;    // CRASH -- y does not have a pointee yet

    y = x;      // Pointer assignment sets y to point to x's pointee

    *y = 13;    // Dereference y to store 13 in its (shared) pointee
}


for (player = 1; someone_has_won == FALSE; player++)
    {
        if (player > total_number_of_players)
        {player = 1;}
        if (is_bankrupt(player))
        {continue;}
        take_turn(player);
    }

for (i = 0; i < test; i) {
    int intValue = test[i];
    // do some work here on intValue
}

 for ( i = 0; i < test.length; i++) {
    int intValue = test[i];
    // do some work here on intValue
}


for (i = 0; i < test; i++) {
    int intValue = test[i];
    // do some work here on intValue
}


int main()
{
    int i;
    int j = 10;

    for( i = 0; i <= j; i ++ )
    {
       if( i == 5 )
       {
          continue;
       }
       printf("Hello %d\n", i );
    }
}
 int main()
 {

    char key;

    Print();

   // system("cls");
    loaduno(key);

    load(key,x,y);

    length=5;

    head.x=25;

    head.y=20;

    head.direction=RIGHT;

    Boarder();

    Food(); //to generate food coordinates initially

    life=3; //number of extra lives

    bend[0]=head;

    Move();   //initialing initial bend coordinate

    return 0;

}



void Move()
{
    int a,i;

    do{

        Food();
        fflush(stdin);

        len=0;

        for(i=0;i<30;i++)

        {

            body[i].x=0;

            body[i].y=0;

            if(i==length)

            break;

        }

        Delay(length);

        Boarder();

        if(head.direction==RIGHT)

            Right();

        else if(head.direction==LEFT)

            Left();

        else if(head.direction==DOWN)

            Down();

        else if(head.direction==UP)

            Up();

        ExitGame();

    }while(!kbhit());

    a=getch();



    if(a==27)

    {

      //  system("cls");

        exit(0);

    }
    key=getch();

    if((key==RIGHT&&head.direction!=LEFT&&head.direction!=RIGHT)||(key==LEFT&&head.direction!=RIGHT&&head.direction!=LEFT)||(key==UP&&head.direction!=DOWN&&head.direction!=UP)||(key==DOWN&&head.direction!=UP&&head.direction!=DOWN))

    {

        bend_no++;

        bend[bend_no]=head;

        head.direction=key;

        if(key==UP)

            head.y--;

        if(key==DOWN)

            head.y++;

        if(key==RIGHT)

            head.x++;

        if(key==LEFT)

            head.x--;

        Move();

    }

    else if(key==27)

    {

       // system("cls");

        exit(0);

    }

    else

    {

        printf("\a");

        Move();

    }
}


  GotoXY(head.x,head.y-i);

void load(){
    int row,col,r,c,q;
    gotoxy(36,14);
    printf("loading...");
    gotoxy(30,15);
    for(r=1;r<=20;r++){
        for(q=0;q<=100000000;q++){

        }//to display the character slowly
    printf("%c",177);}
    getch();
}
void Down()
{
    int i;
    for(i=0;i<=(head.y-bend[bend_no].y)&&len<length;i++)
    {
        GotoXY(head.x,head.y-i);
        // {
        //     if(len==0)
        //         printf("v");
        //     else
        //         printf("*");
        // }
        body[len].x=head.x;
        body[len].y=head.y-i;
        len++;
    }
    Bend();
    if(!kbhit())
        head.y++;
}
void Delay(long k)
{
    Score();
    long i;
    //for(i=0;i<=(10000000);i++);
}
void ExitGame()
{
    int i,check=0;
    for(i=4;i<length;i++)   //starts with 4 because it needs minimum 4 element to touch its own body
    {
        if(body[0].x==body[i].x&&body[0].y==body[i].y)
        {
            check++;    //check's value increases as the coordinates of head is equal to any other body coordinate
        }
        if(i==length||check!=0)
            break;
    }
    if(head.x<=10||head.x>=70||head.y<=10||head.y>=30||check!=0)
    {
        life--;
        if(life>=0)
        {
            head.x=25;
            head.y=20;
            bend_no=0;
            head.direction=RIGHT;
            Move();
        }
        else
        {
            system("cls");
            printf("All lives completed\nBetter Luck Next Time!!!\nPress any key to quit the game\n");
            record();
            exit(0);
        }
    }
}



/*************************************************************************
         Por probar, todos estos casos para abajo no funcionan
***********************************************************************/
//coordinate head, bend[500],food,body[30];


void Food()
{
    if(head.x==food.x&&head.y==food.y)
    {
        length++;
       // time_t a;
        a=time(0);
        srand(a);
        food.x=rand()%70;
        if(food.x<=10)
            food.x+=11;
        food.y=rand()%30;
        if(food.y<=10)

            food.y+=11;
    }
    else if(food.x==0)/*to create food for the first time coz global variable are initialized with 0*/
    {
        food.x=rand()%70;
        if(food.x<=10)
            food.x+=11;
        food.y=rand()%30;
        if(food.y<=10)
            food.y+=11;
    }
}
void Left()
{
    int i;
    for(i=0;i<=(bend[bend_no].x-head.x)&&len<length;i++)
    {

        body[len].x=head.x+i;
        body[len].y=head.y;
        len++;
    }
    Bend();
    if(!kbhit())
        head.x--;

}
void Right()
{
    int i;
    for(i=0;i<=(head.x-bend[bend_no].x)&&len<length;i++)
    {
        //GotoXY((head.x-i),head.y);
        body[len].x=head.x-i;
        body[len].y=head.y;

        len++;
    }
    Bend();
    if(!kbhit())
        head.x++;
}
void Bend()
{
    int i,j,diff;
    for(i=bend_no;i>=0&&len<length;i--)
    {
            if(bend[i].x==bend[i-1].x)
            {
                diff=bend[i].y-bend[i-1].y;
                if(diff<0)
                    // for(j=1;j<=(-diff);j++)
                    // {
                    //     body[len].x=bend[i].x;
                    //     body[len].y=bend[i].y+j;
                    //     GotoXY(body[len].x,body[len].y);
                    //     printf("*");
                    //     len++;
                    //     if(len==length)
                    //         break;
                    // }
                else if(diff>0)
                    for(j=1;j<=diff;j++)
                    {
                        /*GotoXY(bend[i].x,(bend[i].y-j));
                        printf("*");*/
                        body[len].x=bend[i].x;
                        body[len].y=bend[i].y-j;
                        GotoXY(body[len].x,body[len].y);
                        printf("*");
                        len++;
                        if(len==length)
                            break;
                    }
            }
        else if(bend[i].y==bend[i-1].y)
        {
            diff=bend[i].x-bend[i-1].x;
            if(diff<0)
            //     for(j=1;j<=(-diff)&&len<length;j++)
            //     {
            //         /*GotoXY((bend[i].x+j),bend[i].y);
            //         printf("*");*/
            //         body[len].x=bend[i].x+j;
            //         body[len].y=bend[i].y;
            //         GotoXY(body[len].x,body[len].y);
            //             printf("*");
            //        len++;
            //        if(len==length)
            //                break;
            //    }
           else if(diff>0)
               for(j=1;j<=diff&&len<length;j++)
               {
                   /*GotoXY((bend[i].x-j),bend[i].y);
                   printf("*");*/
                   body[len].x=bend[i].x-j;
                   body[len].y=bend[i].y;
                   GotoXY(body[len].x,body[len].y);
                       printf("*");
                   len++;
                   if(len==length)
                       break;
               }
       }
   }
}
void Boarder()
{
   system("cls");
   int i;
   GotoXY(food.x,food.y);   /*displaying food*/
       printf("F");
   for(i=10;i<71;i++)
   {
       GotoXY(i,10);
           printf("!");
       GotoXY(i,30);
           printf("!");
   }
   for(i=10;i<31;i++)
   {
       GotoXY(10,i);
           printf("!");
       GotoXY(70,i);
       printf("!");
   }
}
void Print()
{
   //GotoXY(10,12);
   printf("\tWelcome to the mini Snake game.(press any key to continue)\n");
  getch();
   system("cls");
   printf("\tGame instructions:\n");
   printf("\n-> Use arrow keys to move the snake.\n\n-> You will be provided foods at the several coordinates of the screen which you have to eat. Everytime you eat a food the length of the snake will be increased by 1 element and thus the score.\n\n-> Here you are provided with three lives. Your life will decrease as you hit the wall or snake's body.\n\n-> YOu can pause the game in its middle by pressing any key. To continue the paused game press any other key once again\n\n-> If you want to exit press esc. \n");
   printf("\n\nPress any key to play game...");
   if(getch()==27)
   exit(0);
}
void record(){
   char plname[20],nplname[20],cha,c;
   int i,j,px;
   //FILE *info;
   info=fopen("record.txt","a+");
   getch();
   system("cls");
   printf("Enter your name\n");
   scanf("%[^\n]",plname);
   //************************
   for(j=0;plname[j]!='\0';j++){ //to convert the first letter after space to capital
   nplname[0]=toupper(plname[0]);
   if(plname[j-1]==' '){
   nplname[j]=toupper(plname[j]);
   nplname[j-1]=plname[j-1];}
   else nplname[j]=plname[j];
   }
   nplname[j]='\0';
   //*****************************
   //sdfprintf(info,"\t\t\tPlayers List\n");
   fprintf(info,"Player Name :%s\n",nplname);
    //for date and time

  // time_t mytime;
  mytime = time(NULL);
  fprintf(info,"Played Date:%s",ctime(&mytime));
     //**************************
     fprintf(info,"Score:%d\n",px=Scoreonly());//call score to display score
     //fprintf(info,"\nLevel:%d\n",10);//call level to display level
  // for(i=0;i<=50;i++)
   fprintf(info,"%c",'_');
   fprintf(info,"\n");
   fclose(info);
   printf("wanna see past records press 'y'\n");
   cha=getch();
   system("cls");
   if(cha=='y'){
   info=fopen("record.txt","r");
   do{
       putchar(c=getc(info));
       }while(c!=EOF);}
     fclose(info);
}
int Score()
{
   int score;
   GotoXY(20,8);
   score=length-5;
   printf("SCORE : %d",(length-5));
   score=length-5;
   GotoXY(50,8);
   printf("Life : %d",life);
   return score;
}
int Scoreonly()
{
int score=Score();
system("cls");
return score;
}
void Up()
{
   int i;
   for(i=0;i<=(bend[bend_no].y-head.y)&&len<length;i++)
   {
    //    GotoXY(head.x,head.y+i);
    //    {
    //        if(len==0)
    //            printf("^");
    //        else
    //            printf("*");
    //    }
       body[len].x=head.x;
       body[len].y=head.y+i;
       len++;
   }
   Bend();
   if(!kbhit())
       head.y--;
}

%>

<div>
</body>
</html>