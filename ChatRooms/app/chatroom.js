(function () {

    /*------------------------------------------------------------------------------
    Hub Connection
    ------------------------------------------------------------------------------*/
    var chatHub = $.connection.chatRoomHub;
    var connectionStarted = false;

    // Configure & start
    $.connection.hub.logging = true;
    $.connection.hub.start().done(function () {
        vm.joinChatRoom();
    });

    // Client Methods
    chatHub.client.registerNewUser = function (msg) {
        vm.addMessage(msg);
    }

    chatHub.client.registerMessage = function (msg) {
        vm.addMessage(msg);
    }


    // Common
    var Connected = function () {
        if (typeof ($.connection.hub.id) === 'undefined') {
            vm.connected(false);
            return false;
        }
        vm.connected(true);
        return true;
    }

    /*------------------------------------------------------------------------------
    Chatroom Object
    ------------------------------------------------------------------------------*/
    var chatroomModel = function () {
        this.chatrooms = ko.observableArray();
        this.currentRoom = ko.observable();
        this.previousRoom = ko.observable();
        this.messages = ko.observableArray();
        this.message = ko.observable("");
        this.connected = ko.observable(false);

        // Get list of chatrooms from server
        this.fetchChatRooms();
    };

    chatroomModel.prototype = {

        fetchChatRooms: function () {
            var self = this;
            $.getJSON("/Home/GetChatRooms/", null, function (data) {
                $.each(data, function (idx, chatroom) {
                    self.chatrooms.push(chatroom.Text);
                });
            });
        },

        joinChatRoom: function () {            
            var self = this;
            if ((this.currentRoom === this.previousRoom) || !Connected()) { return; }
            chatHub.server.joinChatRoom(this.currentRoom(), this.previousRoom()).done(
                function () {
                    self.previousRoom(self.currentRoom());
                });                       
        },

        addMessage: function (msg) {
            this.messages.push(msg);
        },

        sendMessage: function () {
            if (!Connected() || this.message() === "") { return;}
            var self = this;
            chatHub.server.sendMessageToChatRoom(this.message(), this.currentRoom()).done(
                function () {
                    self.message("");
                }
            );
        }
    };


    /*------------------------------------------------------------------------------
    View Binding
    ------------------------------------------------------------------------------*/
    var vm = new chatroomModel();
    $(function () {
        ko.applyBindings(vm);
    });


}());