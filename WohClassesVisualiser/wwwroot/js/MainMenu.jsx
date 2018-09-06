var React = require('react');
var MenuItemPressedEnum = require('./MenuItemPressedEnum.js');

class MainMenu extends React.Component {

    constructor(props) {
        super(props);

        this.TutorialClick = this.TutorialClick.bind(this);
        this.LogoutClick = this.LogoutClick.bind(this);
    }

    TutorialClick() {
        this.props.onMenuItemClick(MenuItemPressedEnum.tutorial);
    }

    LogoutClick() {
        this.props.onMenuItemClick(MenuItemPressedEnum.logout);
    }

    render() {
        return <div id="MainMenu" style={{ margin: 'auto', width: '600px', border: '3px solid blue', borderRadius: '30px 15px', padding: '10px' }} >
            <div style={{ margin: 'auto', width: '400px' }}>
                {(this.props.accountData.TutorialComplete != true) && < button id="MainMenu_TutorialBtn" className="btn btn-primary" style={{ width: '100%' }} name="Tutorial" value="Tutorial" onClick={this.TutorialClick}><h3>Tutorial</h3></button>}
                < button id="MainMenu_LogoutBtn" className="btn btn-primary" style={{ width: '100%' }} name="Tutorial" value="Tutorial" onClick={this.LogoutClick}><h3>Logout</h3></button>
            </div>
        </div>;
    }
}

module.exports = MainMenu;