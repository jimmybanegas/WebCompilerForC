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

    int jc = 12, kc = 25;

    int lc = jc & kc;

     int llc = 12, mc = 25;
     int nc = llc | mc;

      int oc = 12, pc = 25;
      int  qc = oc^pc;

      int rc = ~35;
      int sc = ~(-12);

    int num=212, tc;

    int respuesta;

    for (tc=0; tc<=2; ++tc)
       respuesta = num >> tc ;
       // printf("Right shift by %d: %d\n", i, num>>i);

    // for (tci=0; tc<=2; ++tc) 
      //  printf("Left shift by %d: %d\n", i, num<<i);    

char ll = "hola";

 int negativo = -1;

int a = 20;

char b = 'h';

bool c = true;

bool d;

float normalizationFactor = 22.442e2;

int uno = 0xF;
int dos = 00001111;

string hola = "hola mundo";

date fecha = #14-04-1991#;

int e, f=12, g = true, h;

int i = 1 + 2;

string j = "hola " + "mundo";

string k = 'j'+'i';

bool l = 0+1;

int m = 6*5;

int o = 10/5;

float p = 20.5-6.5;

int q = 10-6.5;

bool r = p > q;

bool s = p < q;

int u ;
bool ra ;

if  (ra){ 
    int t = 75;
    u = t;
}
else{
    u = 32;
}
 u++;
 
   int v;
	
   /* for loop execution */
   for( v = 10; v < 20; v = v + 1 ){
      u++;
   }

    for( v = 10; v < 20; v = v + 1 ){
      u--;
   }

   int w = 0;

   while (w < 5){

       u += 10;
       
       w++;
   }

    int x = 10;
    int y;

   /* do loop execution */
   do {
      x = x + 1;
      y++;
   }while( x < 20 );

   const int aa = 20;

   int ab = aa;

   const char ac= 'j';

   char ad = ac;
bool af = false;

bool ag = !af;


    int ij, jk;

    int ae;

    string er;

    while (ij <= 5)
    {
        jk=1;
        while (jk <= ij )
        {           
            jk++;
            er = er + "x";
        }
        ij++;
    }

    int i2=1,j2;
    do
    {
        j2=1;
        do
        {
           // printf("*");
            j2++;
        }while(j2 <= i2);
        i2++;
       // printf("\n");
    }while(i2 <= 5);

     int i3,j3,n = 20;
     bool tr = true;

    for(i3 = 7;i3 <= n;i3 ++)
    {
        for(j3=3;j3<=10;j3++)
        {
            if(tr)
            {
                er = er + "jim-bob-rob";
                break;
            }          
        }

        tr = false;    
    }


 int ic = 5, cc, dc, ec, fc,gc,hc;

    cc = ic;
    dc = cc;
   
    cc += ic; // c = c+a
    ec= cc;

    cc -= ic; // c = c-a
    fc = cc;
  
    cc *= ic; // c = c*a
    gc =cc;
  
    cc /= ic; // c = c/a
    hc=cc;

    cc %= ic; // c = c%


%>

<div>
</body>
</html>