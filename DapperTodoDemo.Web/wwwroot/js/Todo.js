$(function () {
    var Todo = function () {
        function bindEvents(container) {
            container.on("click", "#create-todo", function () {
                $("#todo-create-modal").modal("show");
            });

            //create
            container.on("submit", "#create-todo-form", function (e) {
                e.preventDefault();

                var arr = $(this).serializeArray();
                var data = {};
                $(arr).each(function (index, obj) {
                    data[obj.name] = obj.value;
                });

                $("#todo-create-modal").modal("hide");
                $.ajax({
                    type: 'POST',
                    url: `/TodoItem/Create`,
                    data: data,
                    success: function (result) {
                        var $newContainer = $(result);
                        container.html($newContainer);
                    },
                    error: function (err) {
                        console.error(err.responseJSON.error.message);
                    }
                });
            })

            container.on("click", ".todo-edit", function () {
                $("input[name='id']").val($(this).data("todo-id").toString());
                $("input[name='title']").val($(this).data("todo-title").toString());
                $("input[name='description']").val($(this).data("todo-description").toString());

                if (parseInt($(this).data("todo-status")) === 1) {
                    $("input[name='status']").attr("checked", true);
                }

                $("#todo-edit-modal").modal("show");
            });

            //edit
            container.on("submit", "#todo-edit-modal", function (e) {
                e.preventDefault();

                var data = {
                    id: $("input[name='id']").val(),
                    title: $("input[name='title']").val(),
                    description: $("input[name='description']").val(),
                    status: parseInt($("input[name='status']").val())
                };

                $("#todo-edit-modal").modal("hide");

                $.ajax({
                    type: 'POST',
                    url: `/TodoItem/Update`,
                    data: data,
                    success: function (result) {
                        var $newContainer = $(result);
                        container.html($newContainer);
                    },
                    error: function (err) {
                        console.error(err.responseJSON.error.message);
                    }
                });
            })

            //delete
            container.on("click", ".todo-delete", function () {
                var id = $(this).data("todo-id");

                $.ajax({
                    type: 'POST',
                    url: `/TodoItem/Delete`,
                    data: {id: id},
                    success: function (result) {
                        var $newContainer = $(result);
                        console.log($newContainer);
                        container.html($newContainer);
                    },
                    error: function (err) {
                        console.error(err.responseJSON.error.message);
                    }
                });
            });
        }

        return {
            init: function () {
                bindEvents($("#todo-container"));
            }
        }
    }();

    Todo.init();
});