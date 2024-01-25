# Notes API

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
