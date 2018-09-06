var ReactDOM = require('react-dom');
var React = require('react');
var Battlefield = require('./Battlefield.jsx');
var InfoPannel = require('./InfoPannel.jsx');
var MainMenu = require('./MainMenu.jsx');
var MenuItemPressedEnum = require('./MenuItemPressedEnum.js');

class Application extends React.Component {

    constructor(props) {
        super(props);

        let onloadState = { showMenu: true, showBattlefield: false };
        let emptyAccountData = {TutorialComplete : true };

        this.onHexClick = this.onHexClick.bind(this);

        this.state = { accountData: emptyAccountData, type: "", appState: onloadState, data: "" };
    }

    // загрузка данных
    loadPlayerData() {
        let xhr = new XMLHttpRequest();
        xhr.open("get", this.props.accountDataUrl, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({ accountData: data });
        }.bind(this);
        xhr.send();
    }

    //componentDidMount() {
    //    this.loadPlayerData();
    //}

    componentWillMount() {
        this.loadPlayerData();
    }

    render() {
        return <div>
            {this.state.appState.showBattlefield && <div>
                < div style={{ position: 'relative', float: 'left', border: '3px solid #000', height: '726px', width: '826px', overflow: 'scroll' }}>
                    <Battlefield apiMapUrl={document.getElementById("GetMapUrl").innerHTML} xMax="0" yMax="0" onhexclick={this.onHexClick} />
                </div>
                <InfoPannel type={this.state.type} data={this.state.data} />
            </div>
            }
            {this.state.appState.showMenu && <MainMenu onMenuItemClick={this.onMenuItemClick} accountData={this.state.accountData} />}
        </div>;
    }

    onHexClick(newType, newData) {
        this.setState({ type: newType, data: newData });
    }

    onMenuItemClick(menuItemPressed) {

        if (menuItemPressed == MenuItemPressedEnum.tutorial) {
            window.alert("tutorial pressed");
        }

        if (menuItemPressed == MenuItemPressedEnum.logout) {

            let signoutUrl = document.getElementById("GetSignoutUrl").innerHTML;

            window.location = signoutUrl;
        }
    }
}

ReactDOM.render(
    <Application accountDataUrl={document.getElementById("AccountDataUrl").innerHTML} />,
    document.getElementById("BattlefieldFrame")
);