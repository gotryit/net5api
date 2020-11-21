package main

import (
	"encoding/json"
	"net/http"
)

type person struct {
	Name string     `json:"lastname"`
	Surname string  `json:"firstname"`
}

func myHttpFunc (w http.ResponseWriter, r *http.Request) {
	switch r.Method {
	case http.MethodGet:
		data, _ := json.Marshal(&person{Name: "B", Surname: "Laurentiu"})
		w.Header().Set("Content-Type", "application/json")
		w.Write([]byte(data))
	default:
		w.WriteHeader(http.StatusMethodNotAllowed)
	}

}

func main() {
	http.HandleFunc("/", myHttpFunc)
	http.ListenAndServe(":8080", nil)
}
