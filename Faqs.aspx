<%@ Page Title="" Language="C#" MasterPageFile="~/FirstMaster.Master" AutoEventWireup="true" CodeBehind="Faqs.aspx.cs" Inherits="LifeGymWebsite.WebForm2" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
            .faq-container {
                background: #252525;
                width: 100%;
                padding: 48px;
            }

            .faq-container ul {
                width: 100%;
            }

            .faq-container ul li {
                margin-bottom: 36px;
            }

            .faq-container ul li h4 {
                color: #ffffff;
                margin-bottom: 8px;
            }

            .faq-container ul li p {
                color: #eeeeee;
            }
        </style>

        <!-- Breadcrumb Section Begin -->
        <section class="breadcrumb-section set-bg" data-setbg="assets/img/breadcrumb-bg.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <div class="breadcrumb-text">
                            <h2>FAQ</h2>
                            <div class="bt-option">
                                <a href="./Home.aspx">Home</a>
                                <span>FAQ</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Breadcrumb Section End -->

        <div class="faq-container">
            <ul>

                <li class="faq-cont">
                    <h4>How do I enter the gym?</h4>
                    <p>If it’s your first time to Our Gym, speak to one of our friendly reception team and they’ll give
                        you an
                        entry fob. You can then use the entry fob to access Our Gym during opening hours.</p>
                </li>

                <li class="faq-cont">
                    <h4>Can I bring a friend?</h4>
                    <p>Absolutely. We have one day passes available to purchase for our new clients.</p>
                </li>

                <li class="faq-cont">
                    <h4>What should I wear?</h4>
                    <p>Please wear clothing appropriate to a gym environment (no denim) with proper footwear.</p>
                </li>

                <li class="faq-cont">
                    <h4>How do I book onto a class?</h4>
                    <p>Simply log on to your account, and click ‘Book a class’. Classes can only be booked 24 hours in
                        adv</p>
                </li>
                </li>

                <li class="faq-cont">
                    <h4>Where can I shower?</h4>
                    <p>We have free showers available in our changing rooms on the first floor.</p>
                </li>

                <li class="faq-cont">
                    <h4>What is the minimum age to join Our Gym?</h4>
                    <p>16 years.</p>
                </li>

                <li class="faq-cont">
                    <h4>Are there any student / group / corporate discounts available?</h4>
                    <p>Because we offer such good value memberships, unfortunately there are no other discounted member
                        plans available
                    </p>
                </li>

                <li class="faq-cont">
                    <h4>Do I get anything for referring a friend or family member?</h4>
                    <p>If a friend or family member join as a result of you referring them then you get a FREE 1 Week
                        Personal
                        Training session. It’s easy to set up, all you have to do is get your friends/family to enter
                        your
                        referral
                        code.</p>
                </li>

                <li class="faq-cont">
                    <h4>Are there any lockers?</h4>
                    <p>Yes there are. They cost ₹1000(Monthly) (non-refundable).</p>
                </li>

                <li class="faq-cont">
                    <h4>How long does my Day Pass last?</h4>
                    <p>Day Passes are usuable for 24 hours after the time of purchase.</p>
                </li>

                <li class="faq-cont">
                    <h4>Do I have to have an induction?</h4>
                    <p>We would recommend that you have a group induction that is free of charge.</p>
                </li>

                <li class="faq-cont">
                    <h4>Can I put my membership on hold if I am going on holiday, working away from home or am ill?
                    </h4>
                    <p>You can freeze your membership for a cost of ₹500 per month.</p>
                </li>

                <li class="faq-cont">
                    <h4>What notice do I need to give if I want to leave?</h4>
                    <p>You have to notify our reception area atleast one week prior.</p>
                </li>

                <li class="faq-cont">
                    <h4>How do I cancel my membership?</h4>
                    <p>You have to notify our reception area atleast one week prior.</p>
                </li>

                <li class="faq-cont">
                    <h4>How can I give feedback to the club?</h4>
                    <p>Please email Support.lifegym@gmail.com</p>
                </li>

                <li class="faq-cont">
                    <h4>Can I park my car for free?</h4>
                    <p> Yes, it is free of charge for up to 2 hours. Unfortunately if you stay longer than 2 hours then
                        you will
                        have to buy parking ticket.</p>
                </li>


            </ul>

        </div>

    </asp:Content>