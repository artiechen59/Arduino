
//***********************

#include "uip.h"
#include <string.h>
#include "udpapp.h"
#include "config.h"


#define STATE_INIT 0
#define STATE_LISTENING 1
#define STATE_HELLO_RECEIVED 2
#define STATE_NAME_RECEIVED 3

extern char data[100];

static struct udpapp_state s;

void dummy_app_appcall(void)
{
}
void udpapp_init(void)
{
  uip_ipaddr_t addr;
  struct uip_udp_conn *c;

  //IP address to send packets to
  uip_ipaddr(&addr, 192,168,1,1);

  //create UDP connection to address at port given
  c = uip_udp_new(&addr, HTONS(5556));

  if(c != NULL) {
    uip_udp_bind(c, HTONS(5556));
  }

  s.state = STATE_INIT;
  PT_INIT(&s.pt);
}

static PT_THREAD(handle_connection(void))
{
  //mark beginning of protothreat
  PT_BEGIN(&s.pt);
  
 //give string over to uIP, send packet
  uip_send(data,strlen(data));
 
  //mark end of protothread
  PT_END(&s.pt);
}

void udpapp_appcall(void)
{
  handle_connection();
}
