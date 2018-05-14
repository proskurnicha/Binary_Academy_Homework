# Binary_Academy_Homework :blush:
This is a model that simulates the work of parking. Was added webapi for major classes.
You can clone and run this application in your browser. Initially parking have one car.

```get /api/cars``` - get list all cars

```get /api/cars/{id}``` - get cars by identifier

```post /api/cars``` - add new car 

here use json in body(something like this):
```json
{
        "identifier": "A",
        "balance": 745,
        "carType": 2
}
```
please, do not forget that content-type - application/json
```delete api/cars/{id}``` - delete car by id

```get api/parking/free``` - get count of free places

```get api/parking/occupied``` - get count of occupied places

```get api/balance``` - get balance of parking

```get api/transaction/log```- get Transaction.log

```get api/transaction``` - get all transactions for last minute

```get api/transaction/{id}``` - get transactions for last minute by car identifier

```put api/transaction/{id}``` - top up a balance of machine by identiffier
here use json in body(something like this):
```json
{
    "value": 500
}
```
please, do not forget that content-type - application/json






