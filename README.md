1. :+1: [scheduling-messages-with-rabbitmq](https://www.rabbitmq.com/blog/2015/04/16/scheduling-messages-with-rabbitmq)
2. :+1: [mariuszwojcik.com](https://www.mariuszwojcik.com/rabbitmq-gets-support-for-delayed-messages-delivery/)
3. :+1: [tutorial-one-dotnet](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)


### How to use

`
 docker-compose up -d --build --force-recreate --remove-orphans
`

[ManagementWebApp](http://localhost:15672)

#### Username => guest
#### Password => guest

`
cd Receive
`
`

`
dotnet restore
`

`
dotnet run
`

`
cd Send
`

`
dotnet restore
`

`
dotnet run
`
