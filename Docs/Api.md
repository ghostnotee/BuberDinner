# Buber Dinner Api

Table of contents
- [Buber dinner Api](#buber-dinner-api)
  - [Authentication](#authentication)
    - [Register](#register)
    - [Login](#login)

# Authentication

## Register

```js
POST {{host}}/auth/register
```

### Register request
```json
{
    "firstName" : "Ghost",
    "lastName" : "Note",
    "email" : "ghost@note.com",
    "password" : "ghostNote123"
}
```

### Register response
```js
200 OK
```

## Login

```js
POST {{host}}/auth/login
```

### Login request
```json
{
    "email" : "ghost@note.com",
    "password" : "ghostNote123"
}
```

### Login response
```json
{
    "id" : "5ce9198a-89ac-4da8-8542-5b7107bc2def",
    "firstName" : "Ghost",
    "lastName" : "Note",
    "email" : "ghost@note.com",
    "token" : "weoir..q3wero"
}
```