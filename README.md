# Notes API

A CRUD REST API from scratch using .NET 8. The backend system supports Creating, Reading, Updating and Deleting notes.

## Technologies

    1. ASP.NET 8
    2. dotnet CLI
    3. Visual Studio Code
    4. Visual Studio Code Extension - REST Client

## Architecture

    1. CRUD REST API
    2. Best Practises
    3. Functional Programming
    4. Domain Driven Design

## API Definition

-   [Notes API](#Notes-api)
    -   [Create Note](#create-note)
        -   [Create Note Request](#create-note-request)
        -   [Create Note Response](#create-note-response)
    -   [Get Note](#get-note)
        -   [Get Note Request](#get-note-request)
        -   [Get Note Response](#get-note-response)
    -   [Update Note](#update-note)
        -   [Update Note Request](#update-note-request)
        -   [Update Note Response](#update-note-response)
    -   [Delete Note](#delete-note)
        -   [Delete Note Request](#delete-note-request)
        -   [Delete Note Response](#delete-note-response)

## Create Note

### Create Note Request

```js
POST / notes;
```

```json
{
	"title": "Todo1",
	"description": "This is my first todo.."
}
```

### Create Note Response

```js
201 Created
```

```yml
Location: {{host}}/Notes/{{id}}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"title": "Todo1",
	"description": "This is my first todo..",
	"createdDate": "2024-01-08T08:00:00"
}
```

## Get Note

### Get Note Request

```js
GET /notes/{{id}}
```

### Get Note Response

```js
200 Ok
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"title": "Todo1",
	"description": "This is my first todo..",
	"createdDate": "2024-01-08T08:00:00",
	"modifiedDate": "2024-01-08T08:00:00"
}
```

## Update Note

### Update Note Request

```js
PUT /notes/{{id}}
```

```json
{
	"title": "Todo1",
	"description": "This is my updated todo.."
}
```

### Update Note Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Notes/{{id}}
```

## Delete Note

### Delete Note Request

```js
DELETE /notes/{{id}}
```

### Delete Note Response

```js
204 No Content
```
